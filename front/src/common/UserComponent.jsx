
import React, { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { userService } from "../services/userServices";
import { alertActions } from "../redux/actions/alert.actions";


const UserComponent = ({user}) => {

    return (
      <div className="user-component">
          <h1>{user.email}</h1>
          <p>{user.role}</p>
          <Arrow/>
      </div>
    );
  };

  const Arrow = () => {
    return (
        <div className="arrow">
        </div>
      );
  }

  export default UserComponent;