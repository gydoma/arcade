# Description: Compiles scss files to css
clear
echo "   _____          _____ _____              \n  / ____|  /\    / ____/ ____|             \n | (___   /  \  | (___| (___               \n  \___ \ / /\ \  \___ \\___  \       _    \n  ____) / __/\ \ ____) ____) |     | |     \n |_____/_/ /  \_|_____|______ _  __| | ___ \n          / /\ \ | '__/ __/ _\` |/ _\` |/ _ \\n         / ____ \| | | (_| (_| | (_| |  __/\n        /_/    \_|_|  \___\__,_|\__,_|\___|\n\n" | lolcat -p 1.2;
echo "\t   Made With <3 By: gydoma \n" | lolcat -a -d 40;
echo "\tCurrent Sass version: $(sass --version)\n"
sass --watch --verbose scss/config.scss style.css