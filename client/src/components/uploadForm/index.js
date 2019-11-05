import React from 'react'
import "./uploadForm.css"

export default class UploadForm extends React.Component {
    constructor() {
        super();
        this.state = {
            image: '',
            name: ''
        }
    }
    handleFileChange = e => {
        this.setState({
            [e.target.name]: e.target.files[0],
        })
    }
    handleChange = (name, e) => {
        console.log(e.target.value);
        var change = {};
        change[name] = e.target.value;
        this.setState(change);
    }

    handleSubmit = async e => {
        e.preventDefault();

        const formData = new FormData();
        for (let name in this.state) {
            formData.append(name, this.state[name]);
        }

        await fetch('http://localhost:5005/api/UploadFiles/', {
            method: 'POST',
            body: formData,
        });
        this.state.doneShow = true
    }

    render() {
        return (
            <div className="formUpload">
                <h2>Form Upload</h2>
                {this.state.doneShow ? <div>upload success</div> : ""}
                <form onSubmit={this.handleSubmit}>
                    <div className="col-12">
                        <input
                            placeholder="Name File"
                            className="form-control"
                            name="name"
                            type="text"
                            onChange={this.handleChange.bind(this, 'name')} />
                    </div>
                    <div className="col-12">
                        <input
                            name="image"
                            className="form-control"
                            type="file"
                            onChange={this.handleFileChange} />
                    </div>
                    <div className="col-12">
                        <input type="submit"
                            className="btn btn-primary" />
                    </div>
                </form>
            </div>
        )
    }
}
