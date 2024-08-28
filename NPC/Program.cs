using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NPC;
using NPC.models;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

DiscountConfig discountOptions = new();
builder.Configuration.GetSection(nameof(DiscountConfig))
    .Bind(discountOptions);

var orderManager = new OrderManager(discountOptions);

var order = new OrderInfo(fullPrice: 100, hasFidelityCard: false, hasDisability: false, groupSize: 1, orderDateTime: new DateTime(2024, 08, 28, 22, 0, 0), customerAge: 25);

orderManager.ProcessOrder(order);


