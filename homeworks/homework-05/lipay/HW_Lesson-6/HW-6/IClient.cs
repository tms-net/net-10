

namespace Bank
{
    interface IClient
    {
        string FirstName { get; } //Имя
        string SecondName { get; } //Фамилия
        string Email { get; } //Почта
        string Password { get; } //Пароль
        int Age { get; } //Возраст
       
    }
}
    
