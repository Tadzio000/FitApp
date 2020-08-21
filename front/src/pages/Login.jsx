import React, { useState, useEffect } from 'react';
import { FormInput } from "../common/FormInput"
import { Button } from "reactstrap";
import { useDispatch } from 'react-redux'
import { userService } from '../services/userServices';

import { alertActions } from '../redux/actions/alert.actions'
import { useHistory } from "react-router-dom";

export const LoginPage = (props) => {

    const [userData, setUserData] = useState({})
    const [user, setUser] = useState()
    const history = useHistory();


    const dispatch = useDispatch()

    useEffect(() => {
        console.log('called')
    });

    const handleInput = (e) => {
        userData[e.target.name] = e.target.value;
        setUserData(userData);
        console.log(userData)
    }

    const submitForm = () => {
        userService
            .login(userData)
            .then((data) => {
                setUser(data)
                dispatch(alertActions.success("Congratulations! You are log in."))
                history.push('/plans');
            })
            .catch((error) => {
                console.log(error)
                dispatch(alertActions.error(error.title))
                console.log(error)
            });
    }

    return (
        <div className="container">

            <div className="container__content">
                <FormInput id="email" name="email" onChange={handleInput} label="Email" />
                <FormInput id="password" name="password" onChange={handleInput} label="Password" />
                <Button className="primary-button" id="display-button" color="primary" onClick={submitForm}>
                    login
              </Button>
            </div>


        </div>
    );
}

