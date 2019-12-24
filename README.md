# dotnet3.0.YoutubeExplore

## fork from https://github.com/Tyrrrz/YoutubeExplode/

Step by step Deploy to Heroku:
1. Publish
dotnet publish -c Release

2. Build docker image 

docker build -t kutetai_image ./bin/Release/netcoreapp3.0/publish
 
 Note:  kutetai_image is image name
 ./bin/Release/netcoreapp3.0/publish is a path of folder source publish.
 
 netcoreapp3.0 is a version dotnet core.
 
 3. Docker tag
 
 docker tag kutetai_image registry.heroku.com/taine/web

 Note:  kutetai_image is image name
        taine is a heroku app name.
        
4. Docker push to heroku

docker push registry.heroku.com/taine/web

5. Heroku release 

heroku container:release web -a taine

## Important note:
 #### cd to root folder project to run terminal.
 #### Link to get video info https://youtube.com/get_video_info?video_id=SlPhMPnQ58k&el=embedded&eurl=https%3A%2F%2Fyoutube.googleapis.com%2Fv%2FSlPhMPnQ58k&hl=en
 
 #### ...
