import React, { Component } from 'react';

import './Footer.scss';

class Footer extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		return (
			<footer className="footer page-footer font-small blue">
				<div className="footer__text">
					{new Date().getFullYear()} Vehicle History 
					<br />
					Icons made by 
					<a href="https://www.flaticon.com/authors/monkik" title="monkik"> monkik </a>	
					from 
					<a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com </a>
				</div>
			</footer>
		);
	}
}

export default Footer;