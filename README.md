#Portal#

##Purpose##
Portal is our main application that manages and supports back office processing for the church.  

##How it Works##
This is a web application that is hosted by Fellowship Technologies in IIS.  Clients access the application via browser.

##Requirements##
The Portal Application has a set of requirements both hardware and software related.

##Hardware##
There are no special hardware requirements in order for the web application. The current web servers that run our web applications can be used to host this application.

##Software##
###Microsoft .NET Framework 3.5###
Microsoft .NET Framework 3.5 contains many new features building incrementally upon .NET Framework 2.0 and 3.0, and includes .NET Framework 2.0 service pack 1 and .NET Framework 3.0 service pack 1. 

[.Net Framework][1]

###MSMQ###
MSMQ is a default windows feature that comes with Windows Server and Windows XP and up. Follow the instructions in the link below to install. 

[MSMQ][2]

###MSMQ Private Queue###


##Permissions##
The Application Pool for Portal needs to be run with impersonation using the portal/aspnet account.

##Event Log##
Currently there are no event log distinctions for Portal. 


##Installation##
There is no installation required for Portal

##Upgrading##
Upgrading Portal will comprise of a code drop to all web servers
 
##Version Changes##

###v2.1.5.x###

####Stories included in this build####
* 	F1-1789	Rich Text Editor - Pasting From Word & Plain Text
* 	F1-1767	Task Service Production Prep
* 	F1-1765	Giving the Ability to Hide Applications
* 	F1-1591	Group Category Creation, Workflow, Administration, and Management
* 	F1-1746	Applying a Pledge Drive to a split amount that is not the first line item of the split for a batch credit card transaction
* 	F1-1786	Editing an Existing Contribution Causes a New Contribution to be Added  Instead of Updated
* 	F1-1624	Group Type and Group Data Management
* 	F1-1759	Contribution Statement - Batch Credit Card Reference Field
* 	F1-1611	Iteration on Create a Group Workflow and Adding People to a Group
* 	F1-1750	CC Batch List Page in Dev

####Config Keys Added:####
	+ <add key="Global.F1API.URITemplate" value="http://{0}.api.dev.corp.local/{1}/{2}"/>
	+ <add key="Portal.API.Consumer.Key" value="2"/>
	+ <add key="Portal.API.Consumer.Secret" value="f7d02059-a105-45e0-85c9-7387565f322b" />

	
###Hotfix v2.1.4.x###
After releasing Batch Credit Card into production we were able to see some real world scenarios with churches of all time zones. With that, we noticed a bug where the times of the audit page were inaccurate. Half were in local time while half were in server time. Along with that, a settlement went into a failed status which was very difficult to simulate outside of production. With that, we found a couple bugs around the way we are handling settlement fails.

####Stories included in this build####
* 	F1-1892	UNPL: Batch Credit Card - Audit Log Fixes & 500 Error Fix

A conversion script was written to transform all dates in the batch history table to be server dates. 

	USE ChmContribution
	GO

	SELECT DISTINCT vsc.CHURCH_ID, vsc.VALUE AS TimeZoneID, DISPLAY_NAME AS TimeZoneName, BIAS - 360 AS MinutesDifference
	, bh.CreatedDate, DATEADD(mi, BIAS - 360, bh.CreatedDate) AS Converted_To_CentralDate
	FROM dbo.BatchHistory AS bh
	JOIN ChmPortal.dbo.vw_SettingConfig AS vsc
	     ON bh.ChurchID = vsc.CHURCH_ID
	     AND SETTING_ID = 2
	     AND VALUE <> '115'
	JOIN ChmChurch.dbo.TIME_ZONE AS tz
	     ON tz.TIME_ZONE_ID = vsc.VALUE
	
[1]: http://www.microsoft.com/downloads/details.aspx?FamilyId=333325FD-AE52-4E35-B531-508D977D32A6&displaylang=en	
[2]: http://msdn.microsoft.com/en-us/library/aa967729.aspx
