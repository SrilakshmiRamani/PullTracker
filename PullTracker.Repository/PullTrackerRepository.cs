using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using Autofac;
using AutoMapper;
using PullTracker.Common;
using PullTracker.Contract;
using PullTracker.Facade;

namespace PullTracker.Repository
{
    public class PullTrackerRepository : IPullTrackerRepository
    {
        private readonly IRequestProcessFacade _requestProcessFacade;

        private readonly ConfigurationRepository.ConfigurationRepository configurationInstance =
            ConfigurationRepository.ConfigurationRepository.ConfigurationInstance;

        public PullTrackerRepository()
        {
            _requestProcessFacade = AutofacHelper.Scope.Resolve<IRequestProcessFacade>();
            configurationInstance.RefreshAppSection();

        }

        public PullTrackerRepository(IRequestProcessFacade requestProcessFacade)
        {
            this._requestProcessFacade = requestProcessFacade;
        }

        public Models.Requests GetOpenPullRequests()
        {
            Mapper.CreateMap<Author, Models.Author>();
            Mapper.CreateMap<ChangesetMetadata, Models.ChangesetMetadata>();
            Mapper.CreateMap<Clone, Models.Clone>();
            Mapper.CreateMap<Details, Models.Details>();
            Mapper.CreateMap<FromRef, Models.FromRef>();
            Mapper.CreateMap<Link, Models.Link>();
            Mapper.CreateMap<Links, Models.Links>();
            Mapper.CreateMap<Metadata, Models.Metadata>();
            Mapper.CreateMap<OutGoingPullRequest, Models.OutGoingPullRequest>();
            Mapper.CreateMap<Project, Models.Project>();
            Mapper.CreateMap<PullRequest, Models.PullRequest>();
            Mapper.CreateMap<Contract.Repository, Models.Repository>();
            Mapper.CreateMap<Requests, Models.Requests>();
            Mapper.CreateMap<RequestValues, Models.RequestValues>();
            Mapper.CreateMap<Reviewers, Models.Reviewers>();
            Mapper.CreateMap<Self, Models.Self>();
            Mapper.CreateMap<ToRef, Models.ToRef>();
            Mapper.CreateMap<User, Models.User>();

            var openPullRequest = new List<PullRequest>();

            var repositories = GetProjectRepos();

            foreach (var repository in repositories.Values)
            {
                var requestValues = new List<RequestValues>();

                var openRequest = new PullRequest { Values = new List<RequestValues>() };

                var responseJson = _requestProcessFacade.GetOpenPullRequest(repository.Slug);

                var openRequestObj = JsonConvertor.JsonDeserializer<PullRequest>(responseJson);

                requestValues.AddRange(openRequestObj.Values.Where(pullRequest => pullRequest.Reviewers.Any(reviewer => !reviewer.Approved)));

                if (requestValues.Count <= 0) continue;

                openRequest.Values = requestValues;

                openPullRequest.Add(openRequest);

            }

            var requests = new Requests { PullRequests = openPullRequest };

            var modelRequests = Mapper.Map<Models.Requests>(requests);

            return modelRequests;

        }

        public Models.Requests GetMergeReadyPullRequests()
        {
            Mapper.CreateMap<Author, Models.Author>();
            Mapper.CreateMap<ChangesetMetadata, Models.ChangesetMetadata>();
            Mapper.CreateMap<Clone, Models.Clone>();
            Mapper.CreateMap<Details, Models.Details>();
            Mapper.CreateMap<FromRef, Models.FromRef>();
            Mapper.CreateMap<Link, Models.Link>();
            Mapper.CreateMap<Links, Models.Links>();
            Mapper.CreateMap<Metadata, Models.Metadata>();
            Mapper.CreateMap<OutGoingPullRequest, Models.OutGoingPullRequest>();
            Mapper.CreateMap<Project, Models.Project>();
            Mapper.CreateMap<PullRequest, Models.PullRequest>();
            Mapper.CreateMap<Contract.Repository, Models.Repository>();
            Mapper.CreateMap<Requests, Models.Requests>();
            Mapper.CreateMap<RequestValues, Models.RequestValues>();
            Mapper.CreateMap<Reviewers, Models.Reviewers>();
            Mapper.CreateMap<Self, Models.Self>();
            Mapper.CreateMap<ToRef, Models.ToRef>();
            Mapper.CreateMap<User, Models.User>();

            var mergeReadyPullRequest = new List<PullRequest>();

            var repositories = GetProjectRepos();

            foreach (var repository in repositories.Values)
            {
                var requestValues = new List<RequestValues>();

                var mergeReadyRequest = new PullRequest();

                mergeReadyRequest.Values = new List<RequestValues>();

                var responseJson = _requestProcessFacade.GetMergeReadyPullRequest(repository.Slug);

                var mergeReadyRequestObj = JsonConvertor.JsonDeserializer<PullRequest>(responseJson);

                requestValues.AddRange(mergeReadyRequestObj.Values.Where(pullRequest => pullRequest.Reviewers.Any(reviewer => reviewer.Approved)));

                foreach (var value in requestValues)
                {
                    value.Link.Url = configurationInstance.UrlDomain + value.Link.Url;
                }

                if (requestValues.Count <= 0) continue;

                mergeReadyRequest.Values = requestValues;

                mergeReadyPullRequest.Add(mergeReadyRequest);
            }

            var requests = new Requests { PullRequests = mergeReadyPullRequest };

            var modelRequests = Mapper.Map<Models.Requests>(requests);

            return modelRequests;

        }

        public Models.Requests GetOpenBranches()
        {
            Mapper.CreateMap<Author, Models.Author>();
            Mapper.CreateMap<ChangesetMetadata, Models.ChangesetMetadata>();
            Mapper.CreateMap<Clone, Models.Clone>();
            Mapper.CreateMap<Details, Models.Details>();
            Mapper.CreateMap<FromRef, Models.FromRef>();
            Mapper.CreateMap<Link, Models.Link>();
            Mapper.CreateMap<Links, Models.Links>();
            Mapper.CreateMap<Metadata, Models.Metadata>();
            Mapper.CreateMap<OutGoingPullRequest, Models.OutGoingPullRequest>();
            Mapper.CreateMap<Project, Models.Project>();
            Mapper.CreateMap<PullRequest, Models.PullRequest>();
            Mapper.CreateMap<Contract.Repository, Models.Repository>();
            Mapper.CreateMap<Requests, Models.Requests>();
            Mapper.CreateMap<RequestValues, Models.RequestValues>();
            Mapper.CreateMap<Reviewers, Models.Reviewers>();
            Mapper.CreateMap<Self, Models.Self>();
            Mapper.CreateMap<ToRef, Models.ToRef>();
            Mapper.CreateMap<User, Models.User>();

            var openBranchPullRequest = new List<PullRequest>();

            var repositories = GetProjectRepos();

            foreach (var repository in repositories.Values)
            {
                var requestValues = new List<RequestValues>();

                var openBranchRequest = new PullRequest();

                var responseJson = _requestProcessFacade.GetOpenBranches(repository.Slug);

                var openBranchRequestObj = JsonConvertor.JsonDeserializer<PullRequest>(responseJson);

                foreach (var openBranch in openBranchRequestObj.Values)
                {
                    object value;
                    if (!openBranch.MetaData.TryGetValue("com.atlassian.stash.stash-ref-metadata-plugin:outgoing-pull-request-metadata", out value) && !openBranch.IsDefault)
                    {
                        openBranch.MetaData.TryGetValue(
                            "com.atlassian.stash.stash-branch-utils:latest-changeset-metadata", out value);

                        if (value != null)
                        {
                            var sourceInfo = JsonConvertor.JsonDeserializer<ChangesetMetadata>(value.ToString());
                            var newopenBranch = BuildBranchResponse(repository.Slug, openBranch, sourceInfo);
                            requestValues.Add(newopenBranch);
                        }

                    }
                }

                openBranchRequest.Values = requestValues;

                openBranchPullRequest.Add(openBranchRequest);
            }

            var requests = new Requests { PullRequests = openBranchPullRequest };

            var modelRequests = Mapper.Map<Models.Requests>(requests);

            return modelRequests;

        }

        public Models.Requests GetHooks()
        {
            return new Models.Requests();
        }

        public PullRequest GetProjectRepos()
        {
            var projectRepositories = _requestProcessFacade.GetProjectRepos();

            return projectRepositories;
        }

        /// <summary>
        /// This method build the Branch Object
        /// </summary>
        /// <param name="repositorySlug"></param>
        /// <param name="openBranch"></param>
        /// <param name="sourceInfo"></param>
        /// <returns></returns>
        private RequestValues BuildBranchResponse(string repositorySlug, RequestValues openBranch, ChangesetMetadata sourceInfo)
        {
            var newopenBranch = new RequestValues();

            newopenBranch.ToRef = new ToRef { Repository = new PullTracker.Contract.Repository { Slug = repositorySlug } };
            newopenBranch.Author = new Author { User = new User { DisplayName = sourceInfo.Author.Name } };
            newopenBranch.Link = new Link
            {
                Url =
                   configurationInstance.Repository + repositorySlug + configurationInstance.SourceBranch + openBranch.Id +
                    configurationInstance.TargetBranch
            };
            newopenBranch.FromRef = new FromRef { DisplayId = openBranch.DisplayId };

            newopenBranch.CreatedDate = sourceInfo.AuthorTimeStamp;

            return newopenBranch;
        }
    }
}
