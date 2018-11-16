#!/usr/bin/env bash

echo "Arguments for updating:"
echo " - ACID: $AC_ANDROID"

# Updating manifest
sed -i '' "s/AC_ANDROID/$AC_ANDROID/g" $BUILD_REPOSITORY_LOCALPATH/Finish/MonkeyFinder/MonkeyFinder/Helpers/CommonConstants.cs

echo "AC Constants updated!"