# PullTracker
This application is to track the status of Pull requests of all repositories

Today in GIT, we can see the open / unmerged pull request only if we navigae to the application repository. At times, it is tedious to look into 20 different applications for open / unmerged pull request. This results in the possibility of missing to approve or merge pull requests. This tool helps in avoiding this issue, as it acts as a face for all repositories. 

Below are the features present in the tool today.
1. Open Requests: Will fetch all open pull requests across repositories.
2. Merge Ready: Will fetch all approved but un merged pull requests.
3. Open Branches: Will fetch all branches without a pull request.
4. Build And Merge: Will facilitate merging the branch to master with an integration with Jenkins.
5. Hooks: Fetches the hooks of all repositories
6. Permission: Fetches the permission level for all repositories

To run the application, please configure the below settigns.
1. username: This will be the user name used to login to the git repository
2. password: This will be the password used to login to git repository
3. NetworkUserName: This will be the network username (with domain)
4. UrlDomain: This will be GIT repository Domain URL
5. Repository: This is the GIT Repository Name
6. SourceBranch: This will be  Source Branch path of Stash Api
7. TargetBranch: This will be the TargetBranch Path of Stash Api 
8. Hooks: This will be Hooks path from Stash Api 
9. OpenRequest: This will be the open request path of the Stash Api Call
10. MergeRequest: This will the merge request path of the Stash Api Call
11. Branch:  This will be the Stash Api path to call the Branch

Below are the features in scope for the future:
1. To provide a filter at all columns, so that user can filter the records of his interest.
2. Some performance tuning
3. Implement the features Build And Merge, Hooks and Permission.
4. Provide Pagination for Open Branches to look through all branches (today its deaulted to first 25)
