import React, { Component } from "react";
import "./home.scss";
import { HttpService } from "../../http.service";

export default class Home extends Component {
  state = {
    count: 0
  };

  constructor() {
    super();
  }

  componentWillMount() {}

  onCount(e) {
    e.preventDefault();
    const service = new HttpService();
    service.doGet("values/add").subscribe(
      res => {
        console.log(res);
        service.doGet("values/profiles").subscribe(res => {
          console.log(res);
        });
      },
      err => {
        console.log(err);
      }
    );
  }

  render() {
    return (
      <div>
        <button onClick={this.onCount}>increase</button>
        <h1>Count: {this.state.count}</h1>
      </div>
    );
  }
}
