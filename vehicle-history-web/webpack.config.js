/* eslint-disable no-undef */
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
	mode: 'development',
	resolve: {
		extensions: ['.js', '.jsx', '.css']
	},
	module: {
		rules: [
			{
				test: /\.jsx?$/,
				loader: 'babel-loader'
			},
			{
				test: /\.css$/,
				use: ['style-loader', 'css-loader']
			},
			{
				test: /\.scss$/,
				use: ['style-loader', 'css-loader', 'sass-loader']
			},
			{
				test: /\.(gif|png|jpe?g|svg)$/i,
				loader: 'url-loader?name=src/_assets/[name].[ext]'
			}
		]
	},
	plugins: [new HtmlWebpackPlugin({
		template: './src/index.html'
	})],
	devServer: {
		historyApiFallback: true
	},
	externals: {
		// global app config object
		config: JSON.stringify({
			apiUrl: 'http://localhost:6969'
		})
	}
};