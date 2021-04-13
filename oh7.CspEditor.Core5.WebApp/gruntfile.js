module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: [
                    "node_modules/jquery/dist/jquery.js",
                    "node_modules/bootstrap/dist/js/bootstrap.bundle.js",
                    "node_modules/js-cookie/src/js.cookie.js",
                    "Scripts/js/jquery.editable.js",
                    "Scripts/js/site.js"
                ],
                dest: "temp/scripts.js"
            }
        },
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
        watch: {
            files: ["Scripts/js/*.js"],
            tasks: ["all"]
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");

    grunt.registerTask("all", ["clean", "concat", "jshint", "uglify"]);
};