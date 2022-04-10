import UserService from '/src/services/auth-service/user-service'

class signInDto {
  constructor(username, password) {
    this.username = username;
    this.password = password;
  }
}

const data = new signInDto('Vladimir', '123');

const userService = new UserService();

let token = await userService.SignIn(data);

console.log(token);

console.log(123);