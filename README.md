#forrst-dotnet#

##Purpose##
To Provide a .net wrapper to the [forrst API](http://forrst.com/apidocs.html). The hope is to update this as resources become available  

##How it Works##
The library uses the basic HttpWebRequest to go and get data from [forrst](http://forrst.com).  Each entity will reprsent a corresponding resource from forrst and should be named accordingly

To use the library, just ad a reference to your project.  The following is how you'd get a user based on username:  
`User.Find("nickfloyd")`

##Requirements##
.NET Framework 4.0
Json serialization: I chose to use [James Newton-King's](http://twitter.com/jamesnk) [Json.NET](http://james.newtonking.com/pages/json-net.aspx) serializer over .net data contracts.  
 
##Version Changes##
None

