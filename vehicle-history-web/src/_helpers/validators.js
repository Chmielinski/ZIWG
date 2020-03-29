export const validators = {
	emailValidator,
	alphanumeric
};

function emailValidator(input) {
	return /[A-Za-z0-9._%+-]+@[A-Za-z0-9]+\.[A-Za-z]{2,}/i.test(input);
}

function alphanumeric(input) {
	return /[A-Za-z0-9\s+]/i.test(input);
}