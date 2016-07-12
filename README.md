# SDL_Trados_Automation

This project is a whole set of projects that utilize the automation of SDL Trados.

1. The first project I have completed is to write a c# program to utilize the ability of SDL Trados automation to convert ITD files into SDLXLIFF files. After that SDLXLIFF files can be converted into TMX files.

## Installation.
In order to utilize this automation functionality, there are some steps that you need to preform.

1. Install SDL Trados 2011 or 2014 or 2015.

2. For SDL Trados 2015 user:
	### GOTO http://appstore.sdl.com/developers/sdk.html to download the match version of SDL Trados SDK.
   For SDL Trados 2011 and 2014 user:
   	### GOTO http://appstore.sdl.com/developers/sdk-sdl-trados-studio-2014-2011-2009.html to download the match version of SDL Trados SDK.

   	The things that needs to care about is that you need to install exactly same year version of Trados Studio and SDK, 
   		such as SDL Trados Studio 2015 --> SDL Trados SDK 2015
		   		SDL Trados Studio 2014 --> SDL Trados SDK 2014
		   		SDL Trados Studio 2011 --> SDL Trados SDK 2011
		   		SDL Trados Studio 2009 --> SDL Trados SDK 2009

		   		Currently the compatibility of SDL software is not so good.

3. After installation of SDL Trados SDK, you may use their sample code as start code or write your own code. But you need to link the SDL reference of your project to the dll files in 
	C:\Program Files (x86)\SDL\SDL Trados Studio\Studio3 (For SDL Trados 2014)

	C:\Program Files (x86)\SDL\SDL Trados Studio\Studio4 (For SDL Trados 2015)

4. The API reference pages are in http://producthelp.sdl.com/SDK/StudioIntegrationApi/4.0/html/135dcb1c-535b-46a9-8063-b83be4a06d82.htm 

5. Sample code intro is in http://producthelp.sdl.com/SDK/ProjectAutomationApi/3.0/html/732f4c71-29f9-4960-b951-5590c4a171ad.htm




