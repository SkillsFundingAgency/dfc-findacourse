/// <binding />
"use strict";

// requires

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    sass = require("gulp-sass"),
    eslint = require("gulp-eslint"),
    merge = require("merge-stream"),
    runSequence = require("run-sequence");

// paths

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.scss = paths.webroot + "scss/**/*.scss";
paths.vendorScssDest = paths.webroot + "vendor/scss/";
paths.css = paths.webroot + "css/**/*.css";
paths.cssDest = paths.webroot + "css/";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "dist/js/site.min.js";
paths.concatCssDest = paths.webroot + "dist/css/site.min.css";
paths.vendorJsDest = paths.webroot + "vendor/js/";
paths.vendorJsGovukToolkit = paths.vendorJsDest + "govuk_frontend_toolkit/";
paths.concatJsGovukToolkitDest = paths.vendorJsGovukToolkit + "govuk_toolkit.js";

// dependencies

var jsVendorDeps = {
    "jquery": {
        "dist/**/*.min.js": ""
    },
    "jquery-validation": {
        "dist/**/*.min.js": ""
    },
    "jquery-validation-unobtrusive": {
        "dist/**/*.min.js": ""
    },
    "corejs-typeahead": {
        "dist/typeahead.bundle.min.js": ""
    },
    "govuk_frontend_toolkit": {
        "javascripts/**/*.js": ""
    }
};

var sassVendorDeps = {
    "govuk_frontend_toolkit": {
        "stylesheets/**/*.scss": ""
    },
    "govuk-elements-sass": {
        "public/sass/**/*.scss": ""
    }
};

// tasks

gulp.task("clean:js:vendor", function (cb) {
    rimraf(paths.vendorJsDest + "**/*", cb);
});

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:sass:vendor", function (cb) {
    rimraf(paths.vendorScssDest + "**/*", cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task('sass:vendor', function () {
    var streams = [];

    for (var prop in sassVendorDeps) {
        console.log("Getting vendor sass for: " + prop);
        for (var itemProp in sassVendorDeps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest(paths.vendorScssDest + prop + "/" + sassVendorDeps[prop][itemProp])));
        }
    }

    return merge(streams);
})

gulp.task("sass", function () {
    return gulp.src(paths.scss)
        .pipe(sass({ outputStyle: "expanded" }))
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task("eslint", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(eslint())
        .pipe(eslint.format())
        .pipe(eslint.failAfterError());
});

gulp.task("js:vendor", function () {
    var streams = [];

    for (var prop in jsVendorDeps) {
        console.log("Getting vendor js for: " + prop);
        for (var itemProp in jsVendorDeps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest(paths.vendorJsDest + prop + "/" + jsVendorDeps[prop][itemProp])));
        }
    }

    return merge(streams);
});

gulp.task("js:vendor:govuk_toolkit", function () {
    return gulp.src(paths.vendorJsGovukToolkit + "govuk/**/*.js")
        .pipe(concat(paths.concatJsGovukToolkitDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("sass:watch", function () {
    gulp.watch(paths.scss, ["sass"]);
});

gulp.task("eslint:watch", function () {
    gulp.watch([paths.js, "!" + paths.minJs], ["eslint"]);
});

gulp.task("css:watch", function () {
    gulp.watch([paths.css, "!" + paths.minCss], ["min:css"]);
});

gulp.task("js:watch", function () {
    gulp.watch([paths.js, "!" + paths.minJs], ["min:js"]);
});

// commands

gulp.task("clean", ["clean:js", "clean:js:vendor", "clean:css", "clean:sass:vendor"]);
gulp.task("min", ["min:js", "min:css"]);

//gulp.task("dev", ["clean", "sass:vendor", "css:watch", "sass:watch", "js:vendor", "js:watch", "eslint:watch", "min"]);

gulp.task("dev", function (cb) {
    runSequence("clean", "sass:vendor", "css:watch", "sass:watch", "js:vendor", "js:vendor:govuk_toolkit", "js:watch", "eslint:watch", "min", cb);
});

//gulp.task("prod", ["clean", "sass:vendor", "sass", "js:vendor", "eslint", "min"]);

gulp.task("prod", function (cb) {
    runSequence("clean", "sass:vendor", "sass", "js:vendor", "js:vendor:govuk_toolkit", "eslint", "min", cb);
});