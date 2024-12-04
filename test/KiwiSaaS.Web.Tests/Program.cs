using Microsoft.AspNetCore.Builder;
using KiwiSaaS;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<KiwiSaaSWebTestModule>();

public partial class Program
{
}
