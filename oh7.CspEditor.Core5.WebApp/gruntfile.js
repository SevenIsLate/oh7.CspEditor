module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: ["wwwroot/js/site.js"],
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
                dest: "wwwroot/lib/scripts.min.js"
            }
        },
        watch: {
            files: ["wwwroot/js/*.js"],
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