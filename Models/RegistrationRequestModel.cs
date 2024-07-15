namespace Models;

public record RegistrationRequestModel(
    string Login,
    string PasswordHash,
    int ProvinceId);