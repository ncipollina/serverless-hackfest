# Serverless Architecture Source
This is the source code for the [Azure Government Hackfest](https://www.eventbrite.com/e/microsoft-government-community-event-richmond-va-tickets-42121549689) serverless architecture presentation.  In order to run this code, you'll need to have an existing [Cosmos DB](https://azure.microsoft.com/en-us/services/cosmos-db/) databases and a [SendGrid](https://sendgrid.com/) account.

The CosmosDB binding requires the following app settings to be configured:

``` json
    "AzureWebJobsDocumentDBConnectionString": "ConnectionString"
```
> __Note: Microsoft recommends not using MongoDB API with the input or output bindings.  Data Corruption is possible.

The SendGrid binding requires the following app settings to be configured:
``` json
    "AzureWebJobsSendGridApiKey": "API Key from Azure"
```