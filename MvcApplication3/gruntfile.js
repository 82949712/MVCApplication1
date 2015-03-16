module.exports = function (grunt) {
    'use strict';
 
    //S2    
    grunt.initConfig({
        //S3:Open the package.json
        pkg: grunt.file.readJSON('package.json'),
 
        msbuild: {
            dev: {
                src: ['MvcApplication3.sln'],
                options: {
                    projectConfiguration: 'Debug',
                    maxCpuCount: 1,
                    buildParameters: {
                        VisualStudioVersion: "12.0",
                        Platform: "Any CPU",
                        RunOctoPack: true
                    }
                }
            }
        },

        //S5:Task for Minification
        uglify: {
            options: {
                banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> */\n'
            },
            build: {
                src: 'MvcApplication3/MvcApplication3/angular/modules/student/studentModule.js',
                dest: 'MvcApplication3/MvcApplication3/angular/modules/student/studentModule.min.js'
            }
        }
    });
 
 
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-msbuild');
 
    //S7: the array of tasks
    grunt.registerTask('default', ['uglify', 'msbuild']);
};