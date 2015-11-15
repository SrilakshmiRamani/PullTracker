# PullTracker - A GIT Integrated Tool

## Purpose
The idea is to demonstrate how effectively we can use the REST resources provied by Stash
REST API to develop plugins that enhance the Stash UI. To showcase the usage, AngularJs is used
as the front end tool. The sample application tries to show the best practices when it comes to 
application architecutre including controllers, models, repositories, ApiConsumers and 
Configuration.

##Application Concept
At times, it is tedious to look into 20 different applications for open / unmerged 
pull request or other activites. This tool acts as a visual interface for all repositories to monitor 
activities of all applications like 
		* pull request status
		* application 
		* settings
		* hooks
		* Permissions 
		* Jenkins integration. 

##Build
* AngularJs as front end tool
* Bootstrap.js as frontend backbone
* C# .NET as backend language

##Installation
###Get the Code
Clone the repository using the command
git clone https://github.com/SriRamani87/PullTracker.git

##Application Configuration
Open web.config and configure the below in app settings section.
* username - Configure the user account name that will be used to access GIT (mention this with domain, if any).
* NetworkUserName - Configure the user account name that will be used to access GIT
* password - Configure the user account password that will be used to access GIT
* UrlDomain - Configure the domain URL where your GIT repository reside
* Repository - Append the repository path in your GIT domain to the existing REST path configured
* SourceBranch - Leave the SourceBranch path as is - This is generic for all repositories and domain
* TargetBranch - Leave the TargetBranch path as is - This is generic for all repositories and domain
* Hooks - Leave the Hooks path as is - This is generic for all repositories and domain
* OpenRequest - Leave the OpenRequest path as is - This is generic for all repositories and domain
* MergeRequest - Leave the MergeRequest path as is - This is generic for all repositories and domain
* Branch - Leave the Branch path as is - This is generic for all repositories and domain

##Application Server Configuration
* Open inetmgr on the Server
* Add a new site by configuring to the cloned path
* Complete the site set up

##Implemented Features
Below are the features present in the tool today.
* Open Requests: Will fetch all open pull requests across repositories.
* Merge Ready: Will fetch all approved but un merged pull requests.
* Open Branches: Will fetch all branches without a pull request.
* Build And Merge: Will facilitate merging the branch to master with an integration with Jenkins.
* Hooks: Fetches the hooks of all repositories
* Permission: Fetches the permission level for all repositories

##Proposed Features in Future (Under Development)
Below are the features in scope for the future:
* To provide a filter at all columns, so that user can filter the records of his interest.
* Some performance tuning
* Implement the features Build And Merge, Hooks and Permission.
* Provide Pagination for Open Branches to look through all branches (today its deaulted to first 25)
