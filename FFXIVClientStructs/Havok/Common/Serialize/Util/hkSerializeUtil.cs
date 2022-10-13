// namespace FFXIVClientStructs.Havok;
//
// public unsafe struct hkSerializeUtil
// {
// 	public struct ErrorDetails
// 	{
// 		public enum ErrorID
// 		{
// 			None,
// 			ReadFailed,
// 			UnsupportedFormat,
// 			PackfilePlatform,
// 			VersioningFailed,
// 			NonHeapObject,
// 			LoadFailed,
// 			DeprecatedNotInitialized,
// 			MaxId,
// 		};
//
// 		hkEnum<ErrorID, int> Id;
// 		hkStringPtr DefaultMessage;
// 	};
//
// 	public enum SaveOptionBits
// 	{
// 		Default = 0x00,
// 		TextFormat = 0x01,
// 		SerializeIgnoredMembers = 0x02,
// 		WriteAttributes = 0x04,
// 		Concise = 0x08,
// 	};
// 	
// 	public struct SaveOptions
// 	{
// 		public hkFlags<SaveOptionBits, int> Flags;
// 	};
// 		
// 	enum LoadOptionBits
// 	{
// 		Default = 0x00,
// 		FailIfVersioning = 0x01,
// 		Forced = 0x02,
// 	};
// 	
// 	struct LoadOptions// : 
// 	{
// 		public hkFlags<LoadOptionBits, int> Flags;
// 		//
// 		// public:
// 		// 	HK_DECLARE_NONVIRTUAL_CLASS_ALLOCATOR(0,LoadOptions);
// 		// 	LoadOptions(LoadOptionBits b=LOAD_DEFAULT) : hkFlags<LoadOptionBits,int>(b), m_classNameReg(HK_NULL), m_typeInfoReg(HK_NULL) {}
// 		// 	LoadOptions& useClassNameRegistry(const hkClassNameRegistry* creg) { m_classNameReg = creg; return *this; }
// 		// 	LoadOptions& useTypeInfoRegistry(const hkTypeInfoRegistry* treg) { m_typeInfoReg = treg; return *this; }
// 		//
// 		// 	const hkClassNameRegistry* getClassNameRegistry() const;
// 		// 	const hkTypeInfoRegistry* getTypeInfoRegistry() const;
// 		//
// 		// protected:
// 		// 	const hkClassNameRegistry* m_classNameReg;
// 		// 	const hkTypeInfoRegistry* m_typeInfoReg;
// 	};
//
//
// 		/// Load serialized objects from stream and return pointer
// 		/// to hkResource object.
// 		/// To access hkResource objects you should call hkResource::getContents()
// 		/// or hkResource::getContentsWithRegistry() specifying type of top level
// 		/// object pointer you expect.
// 		/// hkResource is reference counted and users are responsible to
// 		/// remove reference when they do not need the hkResource content.
// 		/// The objects owned by hkResource are not reference counted.
// 		///
// 		/// Load serialized objects from stream and return pointer
// 		/// to hkResource object. If 'classReg' is HK_NULL the
// 		/// class name registry from hkBuiltinTypeRegistry is used instead.
// 		/// The function does additional check for the stream format, versioning and finishing steps.
// 		/// It will return HK_NULL if the checks failed. The error details are
// 		/// returned in 'detailsOut'.
// 		/// Usually you should use hkSerializeUtil::load().
// 		///
// 		/// See also hkNativePackfileUtils::load* for inplace loading.
// 	public static hkResource* HK_CALL load( hkStreamReader* stream, ErrorDetails* detailsOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
// 		/// Load serialized objects from a file using name and return pointer
// 		/// to hkResource object.
// 		/// See hkSerializeUtil::load( hkStreamReader* sr ) for details.
// 	HK_EXPORT_COMMON hkResource* HK_CALL load( const char* filename, ErrorDetails* detailsOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
// 		/// Load serialized objects from buffer and return pointer
// 		/// to hkResource object. The buffer may be freed after loading.
// 		/// See hkSerializeUtil::load( hkStreamReader* sr ) for details.
// 	HK_EXPORT_COMMON hkResource* HK_CALL load( const void* buf, int buflen, ErrorDetails* detailsOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
//
// 		/// Load serialized objects from stream and return pointer
// 		/// to hkObjectResource object.
// 		/// To access hkObjectResource objects you should call hkObjectResource::getContents()
// 		/// or hkObjectResource::getContentsWithRegistry() specifying type of top level
// 		/// object pointer you expect.
// 		/// hkObjectResource is reference counted and users are responsible to
// 		/// remove reference when they do not need its content.
// 		/// The objects owned by hkObjectResource are allocated on heap and reference counted.
// 		///
// 		/// Load serialized objects from stream and return pointer to hkObjectResource object.
// 		/// If 'classReg' or 'typeReg' are null the ones from hkBuiltinTypeRegistry are used.
// 		/// The function does additional check for the stream format, versioning and finishing steps.
// 		/// It will return HK_NULL if the checks failed. The error details are
// 		/// returned in 'detailsOut'.
// 	HK_EXPORT_COMMON hkObjectResource* HK_CALL loadOnHeap( hkStreamReader* stream, ErrorDetails* errorOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
// 		/// Load serialized objects from a file using name and return pointer
// 		/// to hkObjectResource object.
// 		/// See hkSerializeUtil::load( hkStreamReader* sr ) for details.
// 	HK_EXPORT_COMMON hkObjectResource* HK_CALL loadOnHeap( const char* filename, ErrorDetails* errorOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
// 		/// Load serialized objects from a file using name and return pointer
// 		/// to hkObjectResource object.
// 		/// See hkSerializeUtil::load( hkStreamReader* sr ) for details.
// 	HK_EXPORT_COMMON hkObjectResource* HK_CALL loadOnHeap( const void* buf, int buflen, ErrorDetails* errorOut=HK_NULL, LoadOptions options=LOAD_DEFAULT );
//
//
// 	//
// 	// Shortcut loads
// 	//
//
// 		/// Shortcut to combine loadOnHeap and hkObjectResource::stealContents.
// 	template<typename T> inline T* loadObject(hkStreamReader* reader, ErrorDetails* errorOut=HK_NULL);
//
// 		/// Shortcut to combine loadOnHeap and hkObjectResource::stealContents.
// 	template<typename T> inline T* loadObject(const char* filename, ErrorDetails* errorOut=HK_NULL);
//
// 		/// Shortcut to combine loadOnHeap and hkObjectResource::stealContents.
// 	template<typename T> inline T* loadObject(const void* buf, int buflen, ErrorDetails* errorOut=HK_NULL);
//
// 		
//
// 		/// Save a snapshot of a given object in packfile form using provided writer.
// 		/// Returns HK_SUCCESS if successful.
// 		/// If you don't provide a target layout then the current host layout is assumed.
// 		/// NOTE: Some objects are inherently not serializable because they point to
// 		/// external memory, i.e., the vertex and index arrays of an hkpMeshShape.
// 		/// These objects should be converted before saving, i.e hkpMeshShape -> hkpStorageMeshShape
// 		/// (see hkpHavokSnapshot::ConvertListener class for details).
// 		/// If you want these conversions applied you should provide a hkpHavokSnapshot::ConvertListener as
// 		/// a value for userListener.
// 	HK_EXPORT_COMMON hkResult HK_CALL savePackfile( const void* object, const hkClass& klass, hkStreamWriter* writer, const hkPackfileWriter::Options& packFileOptions, hkPackfileWriter::AddObjectListener* userListener=HK_NULL, SaveOptions options=SAVE_DEFAULT );
//
// 		/// Save a snapshot of a given object in tagfile form using provided writer.
// 		/// Returns HK_SUCCESS if successful.
// 		/// NOTE: Some objects are inherently not serializable because they point to
// 		/// external memory, i.e., the vertex and index arrays of an hkpMeshShape.
// 		/// These objects should be converted before saving, i.e hkpMeshShape -> hkpStorageMeshShape
// 		/// (see hkpHavokSnapshot::ConvertListener class for details).
// 		/// If you want these conversions applied you should provide a hkpHavokSnapshot::ConvertListener as
// 		/// a value for userListener.
// 	HK_EXPORT_COMMON hkResult HK_CALL saveTagfile( const void* object, const hkClass& klass, hkStreamWriter* writer, hkPackfileWriter::AddObjectListener* userListener=HK_NULL, SaveOptions options=SAVE_DEFAULT );
//
// 	HK_EXPORT_COMMON hkResult HK_CALL save( const void* object, const hkClass& klass, hkStreamWriter* writer, SaveOptions options=SAVE_DEFAULT );
//
// 		/// Shortcut to save an object with out having to specify the hkClass.
// 	template<typename T> inline hkResult HK_CALL save( const T* object, hkStreamWriter* writer, SaveOptions options=SAVE_DEFAULT );
//
// 		/// Shortcut to save an object with out having to specify the hkClass.
// 	template<typename T> inline hkResult HK_CALL save( const T* object, const char* filename, SaveOptions options=SAVE_DEFAULT );
//
// 		/// The format of an asset file.
// 	enum FormatType
// 	{
// 			/// read or open error.
// 		FORMAT_ERROR,
// 			/// readable but not recognised.
// 		FORMAT_UNKNOWN,
// 			/// binary packfile
// 		FORMAT_PACKFILE_BINARY,
// 			/// XML packfile
// 		FORMAT_PACKFILE_XML,
// 			/// Binary tagfile
// 		FORMAT_TAGFILE_BINARY,
// 			/// XML tagfile
// 		FORMAT_TAGFILE_XML,
// 	};
//
// 		/// Information returned by detectFormat.
// 	struct HK_EXPORT_COMMON FormatDetails
// 	{
//
// 		HK_DECLARE_NONVIRTUAL_CLASS_ALLOCATOR(0, FormatDetails);
//
// 			/// Returns true if the file was serialized after the introduction of predicates
// 		bool supportsPredicates() const { return m_maxPredicateId > hkContentPredicate::NO_PREDICATE; }
//
// 			/// Returns true if the file was serialized with support for this specific predicate.
// 		bool supportsPredicate(hkContentPredicate::PredicateId pred) const { return pred < m_maxPredicateId; }
//
// 		typedef hkHandle<int, -1, FormatDetails> PredicateResult;
//
// 			/// If the given predicate didn't exist when the file was serialized the returned value is invalid
// 			/// (check with PredicateResult::isValid()).
// 			/// If the predicate is true for the content of the file the value (PredicateResult::value())
// 			/// is 1 (true), otherwise it is 0 (false).
// 		PredicateResult verifiesPredicate(hkContentPredicate::PredicateId pred) const;
//
// 			/// The type of the file
// 		hkEnum<FormatType,hkInt32> m_formatType;
// 			/// The version number for the format 
// 		int m_formatVersion;
// 			/// The SDK version which created this file, if known.
// 		hkStringPtr m_version;
// 			/// For binary packfiles, the binary format.
// 		hkStructureLayout::LayoutRules m_layoutRules;
// 			/// This is the value of FilePredicate::MAX_PREDICATE_ID when the file was serialized. Any predicate bigger than this
// 			/// can't be checked against this file.
// 		hkContentPredicate::PredicateId m_maxPredicateId;
// 			/// The list of predicates which are true for the data in the file.
// 		hkArray<hkUint16> m_truePredicates;
// 	};
//
//
// 		/// Detect the type of a packfile stream.
// 	HK_EXPORT_COMMON hkEnum<FormatType,hkInt32> HK_CALL detectFormat( hkStreamReader* reader, ErrorDetails* errorOut=HK_NULL );
//
// 		/// Extract some information from the file header.
// 		/// See FormatDetails for the available information.
// 	HK_EXPORT_COMMON void HK_CALL detectFormat(const char* filename, FormatDetails& detailsOut, ErrorDetails* errorOut=HK_NULL );
// 	HK_EXPORT_COMMON void HK_CALL detectFormat( hkStreamReader* reader, FormatDetails& detailsOut, ErrorDetails* errorOut=HK_NULL );
//
// 		/// Is the stream a tagfile, XML packfile or binary packfile for the current platform?
// 	HK_EXPORT_COMMON hkBool32 HK_CALL isLoadable(hkStreamReader* sr);
// }