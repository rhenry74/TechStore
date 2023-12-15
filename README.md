---
language:
  - csharp
azure:
  - functions
  - CosmosDb
  - static web app
  - blob storage
description: "a site where do it yourselfers can buy firmware"
url: "https://yellow-pond-0c284060f.4.azurestaticapps.net"
---

## TechStore

An e-commerce web site through which product sellers can setup product pages and upload related resources for buyers to purchase. The theme being around the ability to flash firmware on to microcontrollers.

## Contents
Based on an Official Microsoft hands-on tutorial to [publish a Blazor WebAssembly app and .NET API with Azure Static Web Apps](https://docs.microsoft.com/learn/modules/publish-app-service-static-web-app-api-dotnet/?WT.mc_id=mslearn_staticwebapp-github-aapowell).

The tutorial setup an app written in Blazor WebAssembly with a C# Azure Functions API.

+ The data model has been expanded with presistance to CosmosDb added.
+ The product editing component has been enhanced to support the expanded data model including management of lists of artifacts. 

## ToDo 

### Anonymous Mode 
for buyers to search, list and view product detail

### Buyer Mode 
for logged in users enabling the shopping cart and allowing dowload of purchased artifaces including interactive microcontroller firmware flash

### Contributer Mode 
allowing product creation including artifact upload


