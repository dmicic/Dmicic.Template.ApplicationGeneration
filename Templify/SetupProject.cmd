set TemplateName=application-generation-mvc-v1.0

set DestinationFolder="C:\..."
set TemplateFolder="C:\..."
set SolutionName=MyNewSolution

Templify\TemplifyCmd.exe -m d -p %DestinationFolder% -i %TemplateName% -t __NAME__=%SolutionName% -r %TemplateFolder%
