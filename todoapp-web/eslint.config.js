import eslintParserTypescript from '@typescript-eslint/parser';
import eslintPluginImportHelpers from 'eslint-plugin-import-helpers';
import eslintPluginReact from 'eslint-plugin-react';

export default [
  {
    languageOptions: {
      parser: eslintParserTypescript,
      parserOptions: {
        ecmaVersion: 6,
        sourceType: 'module',
        ecmaFeatures: {
          jsx: true,
        },
        useJSXTextNode: true,
      },
    },
    plugins: {
      react: eslintPluginReact,
      'import-helpers': eslintPluginImportHelpers,
    },
    files: ['**/*.ts', '**/*.tsx', '**/*.js'],
    rules: {
      semi: 'error',
      quotes: ['error', 'single'],
      indent: ['error', 2, { SwitchCase: 1 }],
      'eol-last': ['error', 'always'],
      'react/prop-types': 'off',
      'import-helpers/order-imports': [
        'warn',
        {
          newlinesBetween: 'never',
          groups: [
            '/^react/',
            '/^@emotion/',
            '/^@nivo/',
            '/^@fortawesome/',
            '/^jss/',
            '/^ui/',
            '/^api/',
            '/^contexts/',
            '/^hooks/',
            '/^shared/',
            '/^util/',
            ['parent', 'sibling', 'index'],
          ],
          alphabetize: { order: 'asc', ignoreCase: true },
        },
      ],
    },
  },
];
