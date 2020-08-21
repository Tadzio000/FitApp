import { http } from "./http.service";

export const userService = {
    register,
    login,
    allUsers,
  };

const apiURL = "http://test.eba-hxurpixx.eu-west-1.elasticbeanstalk.com"
const localapiURL = "http://localhost:5005"

//
const USER_URL = `${localapiURL}/Users/register`;
const USER_URL3 = `${localapiURL}/Users`;

const USER_URL2 = `${localapiURL}/Users/authenticate`;


  function register(body) {
    return http.post(USER_URL, body);
  }

  function login(body) {
    return http.post(USER_URL2, body);
  }

  function allUsers(body) {
    return http.get(USER_URL3, body);
  }