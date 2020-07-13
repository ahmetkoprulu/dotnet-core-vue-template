const path = require("path");

module.exports = {
	pages: {
		index: {
			entry: "./ClientApp/src/main.js",
			template: "ClientApp/public/index.html",
		},
	},
	configureWebpack: {
		resolve: {
			alias: {
				"@": path.resolve(__dirname, "./ClientApp/src"),
			},
		},
	},
	chainWebpack: (config) => {
		config.plugin("copy").use(require("copy-webpack-plugin"), [
			[
				{
					from: path.resolve(__dirname, "./ClientApp/public"),
					to: path.resolve(__dirname, "dist"),
					toType: "dir",
					ignore: [".DS_Store"],
				},
			],
		]);
	},
	outputDir: "../wwwroot",
};
