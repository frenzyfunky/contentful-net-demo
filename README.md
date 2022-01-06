## ContentfulNetDemo
[Contentful](https://www.contentful.com/) is one of the best headless CMS platforms in the market. It's content structuring mechanism makes it easy to use for different use cases.

In this demo Contentful service is used for a blog website made with .Net Core MVC.

To recreate the development environment:

 - Create a Contentful account 
 - Add the necessery settings to appsettings.json or secrets.json (keys can be got from admin dashboard )
 ```json
 "Contentful": {
    "SpaceId": "<space_id>",
    "DeliveryApiKey": "<delivery_api_key>",
    "PreviewApiKey": "<preview_api_key>",
    "ManagementToken": "<management_token>"
  }
 ```
 
 - Install contentful-cli via npm, yarn or brew
```bash
npm install -g contentful-cli
```
- Import the content model from given content-model.json file (see tutorial [here](https://www.contentful.com/developers/docs/tutorials/cli/import-and-export/))
- Lastly, create entries and assets according to content model from Contentful dashboard