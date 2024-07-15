namespace Models;

public record RegistrationRequest(
    string Login,
    string Password,
    int ProvinceId);