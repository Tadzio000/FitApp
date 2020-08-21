import React, { useState, useEffect } from "react";
import { FormInput } from "../common/FormInput";
import { Button } from "reactstrap";
import { useDispatch } from "react-redux";
import { userService } from "../services/userServices";

import { alertActions } from "../redux/actions/alert.actions";

import UserComponent from "../common/UserComponent";

export const Users = (props) => {
  const [users, setUsers] = useState();
  const dispatch = useDispatch();

  useEffect(() => {
    userService
      .allUsers()
      .then((data) => {
        console.log(data);
        setUsers(data);
        dispatch(alertActions.success("User succesfully loaded!"));
      })
      .catch((error) => {
        console.log(error);
        dispatch(alertActions.error(error.title));
        console.log(error);
      });
  }, []);

  return (
    <div className="container">
        <div className ="users">
      {users && users.map((user) => <UserComponent user={user} />)}
      </div>
    </div>
  );
};
