module.exports = {
  'env': {
    'browser': true,
    'es2021': true,
    'jest': true
  },
  'extends': ['prettier', 'eslint:recommended', 'plugin:react/recommended', 'plugin:@typescript-eslint/recommended', 'plugin:react/jsx-runtime'],
  'overrides': [],
  'parser': '@typescript-eslint/parser',
  'parserOptions': {
    'ecmaVersion': 'latest',
    'sourceType': 'module',
    "ecmaFeatures": {
      "jsx": true
    }
  },
  'plugins': ['react', '@typescript-eslint', 'react-hooks', 'prettier'],
  'rules': {
    'indent': ['error', 2, {
      SwitchCase: 1
    }],
    'quotes': ['error', 'single', {
      avoidEscape: true
    }],
    'semi': ['error', 'always'],
    'no-empty-function': 'off',
    '@typescript-eslint/no-empty-function': 'off',
    'react/display-name': 'off',
    'react/prop-types': 'off',
    'react/react-in-jsx-scope': 'off',
    'prettier/prettier': 'error'
  }
};