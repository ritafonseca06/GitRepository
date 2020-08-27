# CIGNIUM C# Application

This is Console Application that search queries and compares them showing how many results they return, for Example:

```
C:\> searchfight.exe .net java "Java Script" Ruby
```


### Prerequisites

To test this application, you need to obtain the Keys Google Search Engine and Bing , the application needs 3 keys to work :

* Google API Key
* Google Custom Engine Key
* Bing Search Engine Key


### App.config

  <appSettings>
    <add key="urlGoogle" value="https://www.googleapis.com/customsearch/v1?key={0}&amp;cx={1}&amp;q={2}"/>
    <add key="urlBing" value="https://api.cognitive.microsoft.com/bing/v7.0/search"/>
    <add key="GoogleAPIKey" value="GooggleAPIKey"/>
    <add key="GoogleCEKey" value="GoogleCustomEngineKey"/>
    <add key="BingKey" value="BingKey"/>
  </appSettings>

*Programming Challenge:

Searchfight

To determine the popularity of programming languages on the internet we want to you to write an application that queries search engines and compares how many results they return, for example:


    C:\> searchfight.exe .net java

    .net: Google: 4450000000 MSN Search: 12354420
    java: Google: 966000000 MSN Search: 94381485

    Google winner: .net
    MSN Search winner: java
    Total winner: .net

•  The application should be able to receive a variable amount of words
•  The application should support quotation marks to allow searching for terms with spaces (e.g. searchfight.exe “java script”)
•  The application should support at least two search engines
