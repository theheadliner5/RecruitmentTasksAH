import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

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
                <br />
                <p><strong>Name:</strong> {entrepreneur.name}</p>
                <p><strong>NIP:</strong> {entrepreneur.nip}</p>
                <p><strong>Regon:</strong> {entrepreneur.regon}</p>
                <p><strong>Restoration Date:</strong> {entrepreneur.restorationDate}</p>
                <p><strong>Working Address:</strong> {entrepreneur.workingAddress}</p>
                <p><strong>Has Virtual Accounts:</strong> {entrepreneur.hasVirtualAccounts.toString()}</p>
                <p><strong>Status VAT:</strong> {entrepreneur.statusVat}</p>
                <p><strong>KRS:</strong> {entrepreneur.krs}</p>
                <p><strong>Restoration Basis:</strong> {entrepreneur.restorationBasis}</p>
                <p><strong>Account Numbers:</strong></p>
                <ul>
                    {entrepreneur.accountNumbers && entrepreneur.accountNumbers.map((accountNumber, index) => (
                        <li key={index}>{accountNumber.number}</li>
                    ))}
                </ul>
                <p><strong>Registration Denial Basis:</strong> {entrepreneur.registrationDenialBasis}</p>
                <p><strong>Removal Date:</strong> {entrepreneur.removalDate}</p>
                <p><strong>Registration Legal Date:</strong> {entrepreneur.registrationLegalDate}</p>
                <p><strong>Removal Basis:</strong> {entrepreneur.removalBasis}</p>
                <p><strong>Pesel:</strong> {entrepreneur.pesel}</p>
                <p><strong>Representatives:</strong></p>
                <ul>
                    {entrepreneur.representatives && entrepreneur.representatives.map((representative, index) => (
                        <li key={index}>{representative.firstName} {representative.lastName}</li>
                    ))}
                </ul>
                <p><strong>Residence Address:</strong> {entrepreneur.residenceAddress}</p>
                <p><strong>Registration Denial Date:</strong> {entrepreneur.registrationDenialDate}</p>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Enter a NIP and press OK to load data...</em></p>
            : Home.renderEntrepreneurTable(this.state.entrepreneur);

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
