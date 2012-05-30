<Query Kind="Program">
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.Common.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.Client.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.VersionControl.Common.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.VersionControl.Client.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.Build.Client.dll</Reference>
  <Namespace>Microsoft.TeamFoundation.Client</Namespace>
  <Namespace>Microsoft.TeamFoundation.Build.Client</Namespace>
</Query>

void Main()
{
	TeamFoundationServer tfs = new TeamFoundationServer("http://ppfc-ppfdev-002:8080/");
	IBuildServer buildServer = (IBuildServer) tfs.GetService(typeof(IBuildServer));
	
	IBuildDetailSpec buildDetailSpec = buildServer.CreateBuildDetailSpec("Levy", "Levy_INF_64");
	buildDetailSpec.MaxBuildsPerDefinition = 100;
	buildDetailSpec.QueryOrder = BuildQueryOrder.FinishTimeDescending;
	
	IBuildQueryResult results = buildServer.QueryBuilds(buildDetailSpec);
	if (results.Failures.Length == 0)
	{
		results.Builds[0].BuildDefinition.RetentionPolicyList.Dump();
		foreach(IBuildDetail build in results.Builds)
		{
			string.Format("{0}====================================================={0}", Environment.NewLine).Dump();
			build.Dump();
			
			IEnumerable<IBuildInformationNode> infoNodeEnumerable = build.Information.Nodes.Where(x => x.Type == "AssociatedChangeset");
			
			foreach(IBuildInformationNode infoNode in infoNodeEnumerable)
			{
				infoNode.Fields.Dump();
			}
		}
	}
}