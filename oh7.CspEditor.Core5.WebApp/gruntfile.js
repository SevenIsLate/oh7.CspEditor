module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/js/*", "wwwroot/css/*", "temp/"],
        concat: {
            all: {
                src: [
                    "Scripts/js/site.js"
                ],
                dest: "temp/scripts.js"
            }
        },
        copy: {
            main: {
                files: [
                    {
                        expand: true,
                        src: "node_modules/jquery/dist/**",
                        dest: "wwwroot/js/",
                        flatten: true
                    },
                    {
                        expand: true,
                        src: "node_modules/bootstrap/dist/js/**",
                        dest: "wwwroot/js/",
                        flatten: true
                    },
                    {
                        expand: true,
                        src: "node_modules/js-cookie/src/**",
                        dest: "wwwroot/js/",
                        flatten: true
                    },
                    {
                        expand: true,
                        src: "Scripts/js/jquery.editable.js",
                        dest: "wwwroot/js/",
                        flatten: true
                    }
                ]
            }
        }
        ,
        jshint: {
            files: ["temp/*.js"],
            options: {
                "-W069": false
            }
        },
        uglify: {
            all: {
                src: ["temp/scripts.js"],
                dest: "wwwroot/js/scripts.min.js"
            }
        },
        sass: {
            dist: {
                options: {
                    sourcemap: false,
                    compress: false,
                    yuicompress: false,
                    style: "expanded"
                },
                files: {
                    "wwwroot/css/site.css": "Scripts/scss/site.scss",
                    "wwwroot/css/bootstrap.css": "node_modules/bootstrap/scss/bootstrap.scss",
                }
            }
        },
        watch: {
            files: ["Scripts/js/*.js", "**/*.scss"],
            tasks: ["all"]
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-sass");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-watch");

    grunt.registerTask("all", ["clean", "concat", "sass", "jshint", "uglify", "copy"]);
};