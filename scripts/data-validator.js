const fs = require('fs');
const yaml = require('js-yaml');
const versionRegex = /^[0-9]{4}\.[0-9]{2}\.[0-9]{2}\.[0-9]{4}\.[0-9]{4}$/;
const errors = [];
function isNumeric(str) {
    if (typeof str == "number") return !isNaN(str) // if the value is a number, check if it is not NaN
    if (typeof str != "string") return false // we only process strings after this point
    return !isNaN(str) && // use type coercion to parse the _entirety_ of the string (`parseFloat` alone does not do this)...
        !isNaN(parseFloat(str)) // ...and ensure strings of whitespace fail
}
function toHexStringFromNumber(num) {
    return num.toString(16).toUpperCase();
}
function toHex(str) {
    return !isNaN(str) ? toHexStringFromNumber(parseInt(str)) : str;
}
try {
    const doc = yaml.load(fs.readFileSync('./ida/data.yml', 'utf8'));
    if (versionRegex.test(doc.version) === false)
        errors.push('Invalid version format');
    if (typeof doc.globals == "object")
        Object.keys(doc.globals).forEach(key => {
            if (!isNumeric(key) || typeof doc.globals[key] !== 'string') {
                errors.push(`Invalid value for globals.${toHex(key)}: !isNumeric:${!isNumeric(key)}; typeof:${typeof doc.globals[key]}`);
            }
        });
    if (typeof doc.functions == "object")
        Object.keys(doc.functions).forEach(key => {
            if (!isNumeric(key) || typeof doc.functions[key] !== 'string') {
                errors.push(`Invalid value for functions.${toHex(key)}: !isNumeric:${!isNumeric(key)}; typeof:${typeof doc.functions[key]}`);
            }
        });
    if (typeof doc.classes == "object")
        Object.keys(doc.classes).forEach(key => {
            if (typeof key !== 'string')
                errors.push(`Invalid key for classes: ${key}`);
            const classI = doc.classes[key];
            if (classI === null)
                return;
            if (typeof classI !== 'object') {
                errors.push(`Invalid value for classes.${key}: ${typeof classI}`);
            }
            if (classI.hasOwnProperty('funcs') && classI["funcs"])
                Object.keys(classI.funcs).forEach(subkey => {
                    if (!isNumeric(subkey) || typeof classI.funcs[subkey] !== 'string') {
                        errors.push(`Invalid value for classes.${key}.funcs.${toHex(subkey)}: !isNumeric:${!isNumeric(subkey)}; typeof:${typeof classI.funcs[subkey]}`);
                    }
                });
            if (classI.hasOwnProperty('instances') && classI["instances"])
                classI.instances.forEach((instance, i) => {
                    if (instance.hasOwnProperty('ea') && !isNumeric(instance.ea))
                        errors.push(`Invalid value for classes.${key}.instances.${i}.ea: ${instance.ea}`);
                    else if (!instance.hasOwnProperty('ea'))
                        errors.push(`Missing value for classes.${key}.instances.${i}.ea`);
                    if (instance.hasOwnProperty('pointer') && typeof instance.pointer !== 'boolean')
                        errors.push(`Invalid value for classes.${key}.instances.${i}.pointer: ${instance.pointer}`);
                });
            if (classI.hasOwnProperty('vtbls') && classI["vtbls"])
                classI.vtbls.forEach((vtbl, i) => {
                    if (vtbl.hasOwnProperty('ea') && !isNumeric(vtbl.ea))
                        errors.push(`Invalid value for classes.${key}.vtbls.${i}.ea: ${vtbl.ea}`);
                    else if (!vtbl.hasOwnProperty('ea'))
                        errors.push(`Missing value for classes.${key}.vtbls.${i}.ea`);
                    if (vtbl.hasOwnProperty('base') && typeof vtbl.base !== 'string')
                        errors.push(`Invalid value for classes.${key}.vtbls.${i}.base: ${vtbl.base}`);
                    else if (!vtbl.hasOwnProperty('base') && i !== 0)
                        errors.push(`Missing value for classes.${key}.vtbls.${i}.base`);
                });
            if (classI.hasOwnProperty('vfuncs') && classI["vfuncs"])
                Object.keys(classI.vfuncs).forEach(subkey => {
                    if (!isNumeric(subkey) || typeof classI.vfuncs[subkey] !== 'string')
                        errors.push(`Invalid value for classes.${key}.vfuncs.${toHex(subkey)}: !isNumeric:${!isNumeric(subkey)}; typeof:${typeof classI.vfuncs[subkey]}`);
                });
        });
}
catch (e) {
    console.log(e);
    process.exit(1);
}
if (errors.length > 0) {
    errors.forEach(error => console.log(error));
    process.exit(1);
}
