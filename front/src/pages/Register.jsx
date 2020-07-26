import React, {useState, useEffect} from 'react';
import { FormInput } from "../common/FormInput"
import { Button } from "reactstrap";
import { useDispatch } from 'react-redux'
import { userActions } from '../actions/userActions';


export const RegisterPage = (props) => {

    const [user, setUser] = useState([])
    const dispatch = useDispatch()
    
    useEffect(() => {
        console.log('called')
      });

    const handleInput = (e) => {
        user[e.target.name] = e.target.value;
        setUser(user);
        console.log(user)
    }

    const submitForm = () => {
        if (user.email && user.password) {
            dispatch(userActions.register(user));
        }
    }

    return (
    <div>
        test
      <FormInput id = "email" name ="email" onChange = {handleInput} label = "Email"/>
      <FormInput id ="password" name ="password" onChange = {handleInput} label = "Password"/>
      <Button id="display-button" color="primary" onClick={submitForm}>
        Send Data
      </Button>
    </div>
    );
  }

