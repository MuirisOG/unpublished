# unpublished
TLDR: Very simple solution to see unpublished pages in Umbraco

Note
Please be aware that this code is given freely but with the usual caveats. 
Please check your code carefully as I can't be responsible for errors caused by the code in this repository not working.
Please do as I have done, go through the excellent tutorials (some listed below) and do all your testing on a TEST site.
Umbraco is easy to install and it is easy to build a test site.
This code works on Umbraco v7.4.3 and v7.5.13 (webforms) sites.
If you find something horrendous, please let me know. 
Feel free to play around with the code, but please note I have moved on to other projects for the moment.
This was a simple straightforward excercise to get past a particular hurdle, i.e. how to inform backoffice staff of which pages on a large site are awaiting publishing.

**Steps to building your own backoffice app**

Note: The umbraco backoffice is a single page application built using AngularJS.
These are the steps for building your own section/application in the back office, in this case to display pages waiting to be published.
NB: This works for an Umbraco site built using WebForms, but can be adapted for MVC
NB: These notes were for instruction for colleagues so have come from a number of sources, which I think I have fully referenced here.

For reference, please see these links:
The link below shows how to create a simple custom tree and angular editor and dialog.
[http://umbraco.github.io/Belle/#/tutorials/Creating-Editors-Trees](http://umbraco.github.io/Belle/#/tutorials/Creating-Editors-Trees)
NB: See the umbraco TV chapter on API Controllers 
([http://umbraco.tv/videos/umbraco-v7/developer/fundamentals/api-controllers/](http://umbraco.tv/videos/umbraco-v7/developer/fundamentals/api-controllers/))
NB: See the umbraco TV chapter on Property Editors 
([http://umbraco.tv/videos/umbraco-v7/developer/extending/property-editors/](http://umbraco.tv/videos/umbraco-v7/developer/extending/property-editors/))
NB: See this tutorial for an excellent example of using petapoco to update a custom made table in the backoffice
[https://github.com/TimGeyssens/UmbracoAngularBackofficePages/tree/master/UmbracoAngularBackofficePages](https://github.com/TimGeyssens/UmbracoAngularBackofficePages/tree/master/UmbracoAngularBackofficePages) 

Steps:
- create a tree with a menu item 
  (<myPlugin>TreeController, located in /app_code folder - this can contain more than 1 tree)

- create an API controller	
  (<myPlugin>ApiController, located in /app_code folder)

- create an editor, or...
  (i.e. a plugin in the /App_Plugins folder, with a html view and AngularJS controller)

- ...create a dialog for the menu item 
  (i.e. a plugin in the /App_Plugins folder, with a html view and AngularJS controller)

In summary, you will create files as follow:

* /App_Code/CSCode	
Create classes to instantiate your application 
e.g. <MyApp>Application.cs, <MyApp>ApiController.cs, and <MyApp>.cs

* /Config files
Amend the config files applications.config, dashboard.config (the only one edited manually) and trees.config

* /App_Plugins
Create an Umbraco backoffice server side UI with subfolders for /<MyApp>/<myAppTree>, /propertyeditors, /Lang, and 3 files <myApp>.resource.js, <myApp>dashboardintro.html, package.manifest

* /usercontrols		
optionally create usercontrols that can be called from the backoffice (put the link into dashboard.config)

* Backoffice
NB: Make sure to give your back office User account permission to see the new section in Users section of the back office
