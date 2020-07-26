import React from "react";
import { Row, Col } from "reactstrap";
export const ValidationHint = ({ hasError }) => (
  <Row className=" input-error error-hint">
    <Col sm="12">{hasError}</Col>
  </Row>
);