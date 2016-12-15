Wikipedia Map

This is a simple web application for querying links on wikipedia pages. The user submits a word in the main box, and the app will fetch the first 10 pages that link to that Wikipedia page. Then, the user can click on individual nodes for those pages to see what pages link to those further nested pages. The app is built with NancyFX, and d3 Tidy Tree javascript libraries. 

Getting Started

1) Open the WikipediaMap.sln project in Visual Studio
2) Navigate to the Startup.cs class
3) Run the application in Google Chrome
4) Submit a word and see what pages link

----
Alternatively - the app uses OWIN.Nancy hosting and can be run from IIS.

Authors:
Duncan Morrisey

License:
This project is licensed under the MIT License

Acknowledgments:
https://gist.github.com/HermanSontrop/8228664
http://luke.deentaylor.com/wikipedia/ --> inspiration for the project