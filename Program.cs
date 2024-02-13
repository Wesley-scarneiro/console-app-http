
using System.Text.Json;
using ConsoleAppHttp;
using ConsoleAppHttp.Application;
using ConsoleAppHttp.Interface;
using ConsoleAppHttp.Models;
using ConsoleAppHttp.Services;

async Task GetPet(IController controller)
{
    var responseGet = await controller.GetFromJsonAsync<Pet>($"{Settings.ResourcePet}/{111}");
    if (responseGet is not null) Print.PrinColor(ConsoleColor.Yellow, JsonSerializer.Serialize(responseGet));
}

async Task GetStoreOrder(IController controller)
{
    var responseGet = await controller.GetFromJsonAsync<Order>($"{Settings.ResourceOrder}/{222}");
    if (responseGet is not null) Print.PrinColor(ConsoleColor.Yellow, JsonSerializer.Serialize(responseGet));
}

async Task PetController(IHttpService httpService)
{
    var controller = new Controller(httpService);

    Print.PrinColor(ConsoleColor.Green, "PetController");
    // Post
    var pet = new Pet()
    {
        Id = 111,
        Category = new()
        {
            Id = 1,
            Name = "Dog"
        },
        Name = "Scooby",
        PhotoUrls = new List<string?>(),
        Tags = new List<Tag?>(),
        Status = "available"
    };
    var responsePost = await controller.PostFromJsonAsync(Settings.ResourcePet, pet);
    if (responsePost is not null) Print.PrinColor(ConsoleColor.Yellow, JsonSerializer.Serialize(responsePost));

    // Get
   await GetPet(controller);

    // Put
    pet.Tags.Add(new() {Id=1, Name="Cute"});
    pet.PhotoUrls.Add("https://image1.com.br");
    var responsePut = await controller.PutFromJsonAsync<Pet>($"{Settings.ResourcePet}", pet);
    if (responsePut is not null) Print.PrinColor(ConsoleColor.Yellow, JsonSerializer.Serialize(responsePut));

    // Delete
    var responseDel = await controller.DeleteAsync($"{Settings.ResourcePet}/{111}");
    var responseDelPrin = $"StatusCode: {responseDel}";
    if (responseDel is not null) Print.PrinColor(ConsoleColor.Yellow, responseDelPrin);
    await GetPet(controller);
}

async Task StoreController(IHttpService httpService)
{
    var controller = new Controller(httpService);

    Print.PrinColor(ConsoleColor.Green, "StoreController");
    // Post
    var order = new Order()
    {
        Id = 222,
        PetId = 111,
        Quantity = 1,
        ShipDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        Status = "placed",
        Complete = true
    };
    var responsePost = await controller.PostFromJsonAsync(Settings.ResourceOrder, order);
    if (responsePost is not null) Print.PrinColor(ConsoleColor.Yellow, JsonSerializer.Serialize(responsePost));

    // Get
    await GetStoreOrder(controller);

    // Delete
    var responseDel = await controller.DeleteAsync($"{Settings.ResourceOrder}/{222}");
    var responseDelPrin = $"StatusCode: {responseDel}";
    if (responseDel is not null) Print.PrinColor(ConsoleColor.Yellow, responseDelPrin);
    await GetStoreOrder(controller);
}

async Task Run()
{
    var httpService = new HttpService(
    new HttpClient(),
    new Uri(Settings.BaseAddress)
    );

    await PetController(httpService);
    await StoreController(httpService);
}

await Run();