import React from "react";
import { Label } from "./Label";
import { ValidationHint } from "./ValidationHint";
import { Col, Row, Input } from "reactstrap";
export const FormInput = ({
  name,
  label,
  id,
  maxLength,
  max,
  min,
  defaultValue,
  checked,
  required,
  hasError,
  type,
  value,
  disabled,
  labelWidth,
  inputWidth,
  className,
  onClick,
  onChange,
  onBlur,
  onKeyUp,
  onKeyDown,
}) => (
  <React.Fragment>
    <Row className={className}>
      <Col sm={labelWidth}>
        <Label label={label} required={required} hasError={hasError} />
      </Col>
      <Col sm={inputWidth}>
        <Input
          invalid={hasError ? true : false}
          id={id}
          name={name}
          max={max}
          min={min}
          maxLength={maxLength}
          type={type ? type : "text"}
          className={hasError ? "input-error" : ""}
          checked={checked}
          onChange={onChange}
          disabled={disabled}
          onClick={onClick}
          value={value}
          onBlur={onBlur}
          defaultValue={defaultValue}
          onKeyUp={onKeyUp}
          onKeyDown={onKeyDown}
        />
      </Col>
    </Row>
    <ValidationHint hasError={hasError} />
  </React.Fragment>
);