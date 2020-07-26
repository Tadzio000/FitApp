import React from "react";
export const Label = ({ label, required, hasError, onClick, className }) => (
  <label
    onClick={onClick}
    className={hasError ? `input-error ${className}` : `${className}`}
  >
    <span className={onClick ? "clickable" : ""}>
      {required ? (
        <i className="fa fa-asterisk"></i>
      ) : (
        <i className="fa fa-asterisk hidden"></i>
      )}
      {label}
    </span>
  </label>
);