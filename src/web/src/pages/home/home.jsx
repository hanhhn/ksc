import React, { Component } from "react";
import "./home.scss";
import { HttpService } from "../../http.service";

export default class Home extends Component {
  state = {
    count: 0,
    list: []
  };

  componentDidMount() {
    this.getAll();
  }

  onCount(e) {
    e.preventDefault();
    const service = new HttpService();
    service.doGet("values/add").subscribe(
      data => {
        this.setState({
          count: data.count
        });
        this.getAll();
      },
      err => {
        console.log(err);
      }
    );
  }

  getAll() {
    const service = new HttpService();
    service.doGet("values/profiles").subscribe(
      data => {
        this.setState({
          count: data.length,
          list: data
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
        <hr />
        <ul>
          {this.state.list.map((value, index) => {
            return <li key={index}>{value.updateTocken}</li>;
          })}
        </ul>
      </div>
    );
  }
}
