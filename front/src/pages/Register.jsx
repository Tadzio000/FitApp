import React, { useState, useEffect } from 'react';
import { FormInput } from "../common/FormInput"
import { Button } from "reactstrap";
import { useDispatch } from 'react-redux'
import { userService } from '../services/userServices';

import { alertActions } from '../redux/actions/alert.actions'


export const RegisterPage = (props) => {

    const [userData, setUserData] = useState({})
    const dispatch = useDispatch()

    const handleInput = (e) => {
        userData[e.target.name] = e.target.value;
        setUserData(userData);
    }

    
    const submitForm = () => {
        userService
            .register(userData)
            .then((data) => {
                console.log(data)
                dispatch(alertActions.success("User succesfully added!"))
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
                    Register
      </Button>
            </div>


        </div>
    );
}

