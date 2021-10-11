
# TibiaData API - Dotnet Core

A .NET library to call and handle data from [TibiaData API](http://tibiadata.com/)

For now you can check at [TibiaData Doc](https://tibiadata.com/doc-api-v2/) website the current parameters allowed for all functions

___

#### Supported TibiaData API's

**Version 2**

|API|Supported|
|---|---|
|Characters|:heavy_check_mark:|
|Guilds|:heavy_check_mark:|
|Highscores|:heavy_check_mark:|
|Houses|:heavy_check_mark:|
|News|:heavy_check_mark:|
|Worlds|:heavy_check_mark:|

___

#### Install

Clone this repository, build the main project and add it as reference in your project.

> dotnet build TibiaDataApiCore/

#### Usage

```C#
var api = new TibiaDataApi(); // Create the api client instance

// Highscores API
var highscoresList = api.GetHighscore(
    worldName: "Antica", 
    category: HighscoresCategoryEnum.Experience, 
    vocation: HighscoreVocationEnum.Knight);

// Worlds API
var worldsList = api.GetWorlds();
var world = api.GetWorld(worldName: "Antica");

// Characters API
var character = api.GetCharacter(characterName: "Rogi Suvan");

// Guilds API
var guildsList = api.GetGuilds(worldName: "Antica");
var guild = api.GetGuild(guildName: "Red Rose");

// Houses API
var housesList = api.GetHouses(
    worldName: "Antica", 
    city: HousesCityEnum.Venore, 
    type: HousesTypeEnum.Houses);

var house = api.GetHouse(worldName: "Antica", houseId: 40211);

// News API
var latestNewsList = api.GetLatestNews();
var latestNewsTickersList = api.GetLatestNewsTickers();
var news = api.GetNews(newsId: 3560);
```

___

### License
- GNU GPLv3 - GNU General Public License v3.0