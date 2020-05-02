
# FsharpRampart Change Log
All notable changes to this project will be documented in this file aiming to be true to the ported source.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).
 
## 2.0.0 - 2020-05-02
 
Latest code ported. Behavior of relates has changed to accommodate the handling of empty intervals at the bounds. I consider this a breaking change, hence the major version bump. 
 
### Changed
- Add predicates for detecting empty intervals - Ported
- Removed show function - unneeded with built-in fsharp print functions
 
### Fixed
- Handle empty intervals at the bounds - Ported issue fix [#2](https://github.com/tfausak/rampart/issues/2)
 
## [1.0.2] - 2020-03-16
  
### Changed
- Version bumped to more closely match ported repo

### Fixed
 - Ported issue fix [PR #5](https://github.com/tfausak/rampart/pull/5)
 
## [0.1.0] - 2020-03-14
 
### Added
- Initial port of the haskell rampart lib to fsharp
