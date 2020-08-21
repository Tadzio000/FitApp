import React from 'react';
import { Router, Route, Redirect } from 'react-router-dom';

import { RegisterPage } from "./pages/Register"
import { LoginPage } from "./pages/Login"

import { Plans } from "./pages/Plans"
import { Users } from "./pages/Users"

import { createBrowserHistory } from 'history';
import Alert from "../src/common/Alert"

export const history = createBrowserHistory();

function App() {
  return (
    <div className="App">
      <Alert />
      <Router history={history}>
        <Route path="/register" component={RegisterPage} />
        <Route path="/login" component={LoginPage} />
        <Route path="/plans" component={Plans} />
        <Route path="/users" component={Users} />
      </Router>
    </div>
  );
}

export default App;
