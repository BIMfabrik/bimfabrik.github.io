const path = require('path');

module.exports = {
    entry: {
        'main': './Assets/js/index.js',
        'Usecase': './Assets/js/Usecase.js',
        'Platform': './Assets/js/Platform.js',
        'eBKP': './Assets/js/eBKP.js',
        'index': './Assets/scss/index.scss'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: '[name].js'
    },
    resolve: {
        extensions: [".js", ".ts", ".scss"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            },
            {
                test: /\.(scss)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: "index.css"
                        }
                    },
                    {
                        loader: 'extract-loader'
                    },
                    {
                        // Interprets `@import` and `url()` like `import/require()` and will resolve them
                        loader: 'css-loader'
                    },
                    {
                        // Loader for webpack to process CSS with PostCSS
                        loader: 'postcss-loader',
                        options: {
                            plugins: function () {
                                return [
                                    require('autoprefixer')
                                ];
                            }
                        }
                    },
                    {
                        // Loads a SASS/SCSS file and compiles it to CSS
                        loader: 'sass-loader'
                    }
                ]
            }
        ]
    }
};