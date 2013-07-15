setlocal EnableDelayedExpansion  

setlocal TemplateName=application-generation-mvc-v1.0

setlocal DestinationFolder="C:\..."
setlocal TemplateFolder="C:\..."
setlocal SolutionName=MyNewSolution

Templify\TemplifyCmd.exe -m d -p %DestinationFolder% -i %TemplateName% -t __NAME__=%SolutionName% -r %TemplateFolder%
