import React from 'react';
import { Router, Route } from 'react-router-dom';
import {RegisterPage} from "./pages/Register"
import { createBrowserHistory } from 'history';

export const history = createBrowserHistory();

function App() {
  return (
    <div className="App">
                        <Router history={history}>
                                <Route path="/register" component={RegisterPage} />
                        </Router>
    </div>
  );
}

export default App;
