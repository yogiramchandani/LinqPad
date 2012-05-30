<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\EntitySpaces\Redistributables\EntitySpaces.Interfaces.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\EntitySpaces\Redistributables\EntitySpaces.Core.dll</Reference>
  <Reference>C:\dev\tfs10\DataSuite\NLF_2\Common\PPF.BusinessObjects\PPF.BusinessObjects.CDR\bin\Debug\PPF.BusinessObjects.CDR.dll</Reference>
  <Reference>C:\dev\tfs10\DataSuite\NLF_2\Common\PPF.Levy\PPF.Levy.Service\bin\Debug\PPF.Levy.Service.dll</Reference>
  <Namespace>System.ServiceModel</Namespace>
  <Namespace>PPF.Levy.Service</Namespace>
</Query>

void Main()
{
	NetTcpBinding myBinding = new NetTcpBinding();
		
	EndpointAddress myEndpoint = new EndpointAddress("net.tcp://localhost:8005/LevyApplicationWCFServiceFacade");

	ChannelFactory<ILevyApplicationWCFServiceFacade> myChannelFactory = new ChannelFactory<ILevyApplicationWCFServiceFacade>(myBinding, myEndpoint);

	// Create a channel.
	ILevyApplicationWCFServiceFacade wcfClient1 = myChannelFactory.CreateChannel();
	
	var part = wcfClient1.GetAddressTypes();
	part.Dump();
}

// Define other methods and classes here
