import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { entrepreneur: null, loading: true, nip: '' };

        this.handleNipChange = this.handleNipChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNipChange(event) {
        this.setState({ nip: event.target.value });
    }

    async handleSubmit(event) {
        event.preventDefault();
        const response = await fetch(`entrepreneur/${this.state.nip}`);
        const data = await response.json();
        this.setState({ entrepreneur: data, loading: false });
    }

    static renderEntrepreneurTable(entrepreneur) {
        return (
            <div>
                <p><strong>Name:</strong> {entrepreneur.name}</p>
                <p><strong>NIP:</strong> {entrepreneur.nip}</p>
                {/* ...Add more fields as you need them... */}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Enter a NIP and press OK to load data...</em></p>
            : FetchData.renderEntrepreneurTable(this.state.entrepreneur);

        return (
            <div>
                <h1 id="tableLabel">Entrepreneur Data</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <input type="text" value={this.state.nip} onChange={this.handleNipChange} />
                <button onClick={this.handleSubmit}>OK</button>
                {contents}
            </div>
        );
    }
}
